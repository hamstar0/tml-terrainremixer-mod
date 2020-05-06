using System;
using System.ComponentModel;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Terraria;
using Terraria.ModLoader.Config;
using HamstarHelpers.Helpers.World;


namespace TerrainRemixer {
	public enum WorldDepth {
		Sky,
		Surface,
		UgDirt,
		UgRock,
		Underworld,
		Bottom
	}




	public partial class TerrainRemixerGenPassSpec {
		public static int GetDepthTile( WorldDepth depth ) {
			switch( depth ) {
			case WorldDepth.Sky:
				return 0;
			case WorldDepth.Surface:
				return WorldHelpers.SurfaceLayerTopTileY;
			case WorldDepth.UgDirt:
				return WorldHelpers.DirtLayerTopTileY;
			case WorldDepth.UgRock:
				return WorldHelpers.RockLayerTopTileY;
			case WorldDepth.Underworld:
				return WorldHelpers.UnderworldLayerTopTileY;
			case WorldDepth.Bottom:
				return Main.maxTilesY - 1;
			default:
				return -1;
			}
		}



		////////////////

		[Range( -1000, 1000 )]
		[DefaultValue( 0 )]
		public int BoundsTopTileOffset { get; set; } = 0;

		[Range( -1000, 1000 )]
		[DefaultValue( 0 )]
		public int BoundsBottomTileOffset { get; set; } = 0;

		////

		[DrawTicks]
		[JsonConverter( typeof( StringEnumConverter ) )]
		[DefaultValue( WorldDepth.Sky )]
		public WorldDepth BoundsTopStart {
			get => this._BoundsTopStart;
			set {
				if( (int)value < (int)this._BoundsBottomStart ) {
					this._BoundsTopStart = value;
				}
			}
		}
		private WorldDepth _BoundsTopStart = WorldDepth.Sky;

		[DrawTicks]
		[JsonConverter( typeof( StringEnumConverter ) )]
		[DefaultValue( WorldDepth.UgRock )]
		public WorldDepth BoundsBottomStart {
			get => this._BoundsBottomStart;
			set {
				if( (int)value > (int)this._BoundsTopStart ) {
					this._BoundsBottomStart = value;
				}
			}
		}
		private WorldDepth _BoundsBottomStart = WorldDepth.UgRock;

		////////////////

		[Range( -1000, 1000 )]
		[DefaultValue( 0 )]
		public int BoundsLeftTileOffset { get; set; } = 0;

		[Range( -1000, 1000 )]
		[DefaultValue( 0 )]
		public int BoundsRightTileOffset { get; set; } = 0;

		////

		[Range( 0f, 1f )]
		[DefaultValue( 0f )]
		public float BoundsLeftPercentStart {
			get => this._BoundsLeftPercentStart;
			set {
				if( (int)value < (int)this._BoundsRightPercentStart ) {
					this._BoundsLeftPercentStart = value;
				}
			}
		}
		private float _BoundsLeftPercentStart = 0f;

		[Range( 0f, 1f )]
		[DefaultValue( 1f )]
		public float BoundsRightPercentStart {
			get => this._BoundsRightPercentStart;
			set {
				if( (int)value > (int)this._BoundsLeftPercentStart ) {
					this._BoundsRightPercentStart = value;
				}
			}
		}
		private float _BoundsRightPercentStart = 1f;
	}
}
