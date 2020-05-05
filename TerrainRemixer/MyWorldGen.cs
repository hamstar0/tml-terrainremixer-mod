using System;
using Terraria;
using Terraria.World.Generation;
using HamstarHelpers.Helpers.World;
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


		private void ApplyPass( GenerationProgress progress, TerrainRemixerPassDefinition passDef ) {
			int topY, botY;
			this.GetVerticalTileRange( passDef, out topY, out botY );

			FastNoise noise;
			var map = TerrainRemixerGenPass.GetNoiseMap( Main.maxTilesX, botY - topY, passDef.Scale, out noise );

			for( int y = topY; y < botY; y++ ) {
				for( int x = 0; x < Main.maxTilesX; x++ ) {
					Tile tile = Main.tile[x, y];
					if( tile?.active() != true ) { continue; }
					
					float solidThreshold, wallThreshold;
					this.GetSoftenerPercentThresholds( passDef, out solidThreshold, out wallThreshold );    //x, y, topY, botY

					//float val = noise.GetNoise( x, y );
					float val = map.map[ TerrainRemixerGenPass.GetMapCoord(x, y, topY) ];
					val -= map.minVal;
					val /= map.maxVal - map.minVal;

					this.ApplySofteningToTile( tile, val, solidThreshold, wallThreshold );
				}
			}
		}
		

		////////////////

		public void GetVerticalTileRange( TerrainRemixerPassDefinition passDef, out int topY, out int botY ) {
			topY = WorldHelpers.SurfaceLayerTopTileY;
			botY = passDef.MaxDepthOffset;
			
			if( passDef.IsMaxDepthSurfaceBottom ) {
				botY += WorldHelpers.SurfaceLayerBottomTileY;
			} else if( passDef.IsMaxDepthDirtLayerBottom ) {
				botY += WorldHelpers.DirtLayerBottomTileY;
			} else if( passDef.IsMaxDepthRockLayerBottom ) {
				botY += WorldHelpers.RockLayerBottomTileY;
			} else {
				botY += WorldHelpers.UnderworldLayerBottomTileY;
			}
		}

		private void GetSoftenerPercentThresholds(
					TerrainRemixerPassDefinition passDef,
					out float solidMinPercThresh,
					out float wallMinPercThresh ) {
			/*int x,
			int y,
			int topY,
			int botY,
			float tileRangeY = botY - topY;*/

			solidMinPercThresh = passDef.BaseNoisePercentThresholdMinimumForSolid;
			wallMinPercThresh = passDef.BaseNoisePercentThresholdMinimumForWall;
			
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
					float minPercThreshWhileSolid,
					float minPercThreshWhileWall ) {
			if( percent < minPercThreshWhileSolid ) {
				tile.active( false );
			}
			if( percent < minPercThreshWhileWall ) {
				tile.wall = 0;
				tile.wallColor( 0 );
				tile.wallFrameNumber( 0 );
				tile.wallFrameX( 0 );
				tile.wallFrameY( 0 );
			}
		}
	}
}
