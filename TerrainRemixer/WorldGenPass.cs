using System;
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
			int topY, botY;
			this.GetVerticalTileRange( passSpec, out topY, out botY );

			FastNoise noise;
			var map = TerrainRemixerGenPass.GetNoiseMap( Main.maxTilesX, botY - topY, passSpec.Scale, out noise );

			for( int y = topY; y < botY; y++ ) {
				for( int x = 0; x < Main.maxTilesX; x++ ) {
					Tile tile = Main.tile[x, y];
					if( tile?.active() != true ) { continue; }
					
					float solidThreshold;
					this.GetSoftenerPercentThresholds( passSpec, out solidThreshold );    //x, y, topY, botY

					//float val = noise.GetNoise( x, y );
					float val = map.map[ TerrainRemixerGenPass.GetMapCoord(x, y, topY) ];
					val -= map.minVal;
					val /= map.maxVal - map.minVal;

					this.ApplySofteningToTile( tile, val, solidThreshold );
				}
			}
		}
		

		////////////////

		public void GetVerticalTileRange( TerrainRemixerGenPassSpec passSpec, out int topY, out int botY ) {
			topY = TerrainRemixerGenPassSpec.GetDepthTile(passSpec.DepthStartBase) + passSpec.DepthOffsetTop;
			botY = TerrainRemixerGenPassSpec.GetDepthTile(passSpec.DepthEndBase) + passSpec.DepthOffsetBottom;
		}

		private void GetSoftenerPercentThresholds(
					TerrainRemixerGenPassSpec passSpec,
					out float solidMinPercThresh ) {
			/*int x,
			int y,
			int topY,
			int botY,
			float tileRangeY = botY - topY;*/

			solidMinPercThresh = passSpec.NoisePercentThresholdMinimum;
			
			/*if( config.IsSoftenerGradient ) {
				float deepSolidPercent = (float)(y - topY) / tileRangeY;
				solidPercThresh *= deepSolidPercent;

				float wallSolidPercent = (float)(y - topY) / tileRangeY;
				solidPercThresh *= wallSolidPercent;
			}*/
		}

		private void ApplySofteningToTile(
					Tile tile,
					float percent,
					float minPercThreshWhileSolid ) {
			if( percent < minPercThreshWhileSolid ) {
				tile.active( false );
			//}
			//if( percent < minPercThreshWhileWall ) {
				tile.wall = 0;
				tile.wallColor( 0 );
				tile.wallFrameNumber( 0 );
				tile.wallFrameX( 0 );
				tile.wallFrameY( 0 );
			}
		}
	}
}
