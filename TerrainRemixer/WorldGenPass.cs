using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using FastNoiseCSharp;
using Terraria;
using Terraria.World.Generation;
using HamstarHelpers.Helpers.Debug;


namespace TerrainRemixer {
	partial class TerrainRemixerGenPass : GenPass {
		internal TerrainRemixerGenPass() : base( "Remixing Terrain", 1f ) { }


		////

		public override void Apply( GenerationProgress progress ) {
			var config = TerrainRemixerConfig.Instance;
			var passes = config.Get<List<TerrainRemixerGenPassSpec>>( nameof(config.Passes) );

			progress.Message = "Remixing Terrain";   //Lang.gen[76].Value+"..Thin Ice"

			for( int i=0; i<passes.Count; i++ ) {
				this.ApplyPass( progress, passes[i] );
			}

			progress.Set( 1f );
		}


		private void ApplyPass( GenerationProgress progress, TerrainRemixerGenPassSpec passSpec ) {
			Rectangle tileArea = this.GetRegion( passSpec );

			(float[], float, float) map = TerrainRemixerGenPass.GetNoiseMap(
				Main.maxTilesX,
				tileArea.Height,
				passSpec.NoiseFrequency,
				passSpec.IsWorms,
				passSpec.Sharpness,
				//passSpec.IsPerturbed,
				out FastNoise _
			);

			float totalTiles = tileArea.Height * Main.maxTilesX;
			int botY = tileArea.Bottom;
			int rightX = tileArea.Right;

			for( int y = tileArea.Y; y < botY; y++ ) {
				for( int x = tileArea.X; x < rightX; x++ ) {
					this.ApplyPassToTile( passSpec, tileArea, map, x, y );

					// Update progress:
					float currTile = x + ((y - tileArea.Y) * Main.maxTilesX);
					progress.Set( currTile / totalTiles );
				}
			}
		}

		private void ApplyPassToTile(
					TerrainRemixerGenPassSpec passSpec,
					Rectangle tileArea,
					(float[] map, float minVal, float maxVal) noiseMap,
					int tileX,
					int tileY ) {
			Tile tile = Main.tile[tileX, tileY];
			if( tile?.active() != true ) {
				return;
			}

			float noiseStrPerc = this.GetRemixerNoiseStrengthPercent( passSpec, tileArea, tileX, tileY );

			//float val = noise.GetNoise( x, y );
			int coord = TerrainRemixerGenPass.GetMapCoord( tileX, tileY, tileArea.Y );
			float randVal = noiseMap.map[ coord ];
			randVal -= noiseMap.minVal;
			randVal /= noiseMap.maxVal - noiseMap.minVal;

			// Check API or else apply fade amounts according to spec
			if( !TerrainRemixerAPI.ApplyTileRemixers(passSpec, tileX, tileY, ref noiseStrPerc, ref randVal) ) {
				float noiseMin = passSpec.NoiseValueMinimumUntilTileRemoval * noiseStrPerc;

				this.ApplyRemixingToTile( tile, randVal, noiseMin );
			}
		}
		

		////////////////

		public Rectangle GetRegion( TerrainRemixerGenPassSpec passSpec ) {
			int leftX = (int)(passSpec.BoundsLeftPercentStart * (float)(Main.maxTilesX-1)) + passSpec.BoundsLeftTileOffset;
			int rightX = (int)(passSpec.BoundsRightPercentStart * (float)(Main.maxTilesX-1)) + passSpec.BoundsRightTileOffset;
			int topY = TerrainRemixerGenPassSpec.GetDepthTile(passSpec.BoundsTopStart) + passSpec.BoundsTopTileOffset;
			int botY = TerrainRemixerGenPassSpec.GetDepthTile(passSpec.BoundsBottomStart) + passSpec.BoundsBottomTileOffset;

			float topPerc = passSpec.BoundsTopPercentStart;
			float botPerc = passSpec.BoundsBottomPercentStart;
			int topRange = TerrainRemixerGenPassSpec.GetDepthTile( passSpec.BoundsTopStart + 1 )
				- TerrainRemixerGenPassSpec.GetDepthTile( passSpec.BoundsTopStart );
			int botRange = TerrainRemixerGenPassSpec.GetDepthTile( passSpec.BoundsBottomStart )
				- TerrainRemixerGenPassSpec.GetDepthTile( passSpec.BoundsBottomStart - 1 );

			topY += (int)(topPerc * (float)topRange);
			botY -= (int)(botPerc * (float)botRange);

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
