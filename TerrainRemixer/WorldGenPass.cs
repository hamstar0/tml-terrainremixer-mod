using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.World.Generation;
using HamstarHelpers.Helpers.Debug;
using FastNoiseCSharp;


namespace TerrainRemixer {
	partial class TerrainRemixerGenPass : GenPass {
		internal TerrainRemixerGenPass() : base( "Remixing Terrain", 1f ) { }


		////

		public override void Apply( GenerationProgress progress ) {
			var config = TerrainRemixerConfig.Instance;

			progress.Message = "Remixing Terrain";   //Lang.gen[76].Value+"..Thin Ice"

			for( int i=0; i<config.Passes.Count; i++ ) {
				this.ApplyPass( progress, config.Passes[i] );
			}

			progress.Set( 1f );
		}


		private void ApplyPass( GenerationProgress progress, TerrainRemixerGenPassSpec passSpec ) {
			Rectangle tileArea = this.GetRegion( passSpec );

			FastNoise noise;
			var map = TerrainRemixerGenPass.GetNoiseMap( Main.maxTilesX, tileArea.Height, passSpec.NoiseScale, out noise );

			float totalTiles = tileArea.Height * Main.maxTilesX;
			int botY = tileArea.Bottom;
			int rightX = tileArea.Right;

			for( int y = tileArea.Y; y < botY; y++ ) {
				for( int x = tileArea.X; x < rightX; x++ ) {
					Tile tile = Main.tile[x, y];
					if( tile?.active() != true ) { continue; }
					
					float noiseStrPerc = this.GetRemixerNoiseStrengthPercent( passSpec, tileArea, x, y );    //x, y, topY, botY

					//float val = noise.GetNoise( x, y );
					float randVal = map.map[ TerrainRemixerGenPass.GetMapCoord(x, y, tileArea.Y) ];
					randVal -= map.minVal;
					randVal /= map.maxVal - map.minVal;

					// Check API or else apply fade amounts according to spec
					if( !TerrainRemixerAPI.ApplyTileRemixers(passSpec, x, y, ref noiseStrPerc, ref randVal) ) {
						float noiseMin = passSpec.NoiseValueMinimumUntilTileRemoval * noiseStrPerc;

						this.ApplyRemixingToTile( tile, randVal, noiseMin );
					}

					// Update progress:
					float currTile = x + ((y - tileArea.Y) * Main.maxTilesX);
					progress.Set( currTile / totalTiles );
				}
			}
		}
		

		////////////////

		public Rectangle GetRegion( TerrainRemixerGenPassSpec passSpec ) {
			int leftX = (int)(passSpec.BoundsLeftPercentStart * (float)(Main.maxTilesX-1)) + passSpec.BoundsLeftTileOffset;
			int rightX = (int)(passSpec.BoundsRightPercentStart * (float)(Main.maxTilesX-1)) + passSpec.BoundsRightTileOffset;
			int topY = TerrainRemixerGenPassSpec.GetDepthTile(passSpec.BoundsTopStart) + passSpec.BoundsTopTileOffset;
			int botY = TerrainRemixerGenPassSpec.GetDepthTile(passSpec.BoundsBottomStart) + passSpec.BoundsBottomTileOffset;

			return new Rectangle(
				x: Math.Max( leftX, 0 ),
				y: Math.Max( topY, 0 ),
				width: Math.Min( rightX - leftX, Main.maxTilesX-1 ),
				height: Math.Min( botY - topY, Main.maxTilesY-1 )
			);
		}

		private float GetRemixerNoiseStrengthPercent(
					TerrainRemixerGenPassSpec passSpec,
					Rectangle tileArea,
					int tileX,
					int tileY ) {
			float horizThreshPerc = passSpec.HorizontalDistancePercentFromCenterBeforeBlending;
			float vertThreshPerc = passSpec.VerticalDistancePercentFromCenterBeforeBlending;

			float xOff = tileX - tileArea.X;
			float yOff = tileY - tileArea.Y;
			float xPerc = xOff / (float)tileArea.Width;
			float yPerc = yOff / (float)tileArea.Height;

			float xPercFromMid = Math.Abs( xPerc - 0.5f ) * 2f;
			float yPercFromMid = Math.Abs( yPerc - 0.5f ) * 2f;

			float xPercPastThresh = Math.Max( xPercFromMid - horizThreshPerc, 0f );
			float yPercPastThresh = Math.Max( yPercFromMid - vertThreshPerc, 0f );

			float horizThreshPercDiff = 1f - horizThreshPerc;
			float vertThreadPercDiff = 1f - vertThreshPerc;

			float xWeakenPerc = horizThreshPercDiff > 0f
				? xPercPastThresh / horizThreshPercDiff
				: 1f;
			float yWeakenPerc = vertThreadPercDiff > 0f
				? yPercPastThresh / vertThreadPercDiff
				: 1f;

			if( xWeakenPerc > yWeakenPerc ) {
				return 1f - xWeakenPerc;
			} else {
				return 1f - yWeakenPerc;
			}
		}

		////

		private void ApplyRemixingToTile(
					Tile tile,
					float noiseVal,
					float minPercThreshWhileSolid ) {
			if( noiseVal < minPercThreshWhileSolid ) {
				tile.active( false );
				tile.wall = 0;
				tile.wallColor( 0 );
				tile.wallFrameNumber( 0 );
				tile.wallFrameX( 0 );
				tile.wallFrameY( 0 );
			}
		}
	}
}
