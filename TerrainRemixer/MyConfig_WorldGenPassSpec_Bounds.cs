﻿using System;
using System.ComponentModel;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Terraria;
using Terraria.ModLoader.Config;
using ModLibsGeneral.Libraries.World;


namespace TerrainRemixer {
	public enum WorldDepth {
		SkyTop,
		SurfaceTop,
		UndergroundDirtTop,
		UndergroundRockTop,
		UnderworldTop,
		Bottom
	}




	public partial class TerrainRemixerGenPassSpec {
		public static int GetDepthTile( WorldDepth depth ) {
			switch( depth ) {
			case WorldDepth.SkyTop:
				return 0;
			case WorldDepth.SurfaceTop:
				return WorldLocationLibraries.SurfaceLayerTopTileY;
			case WorldDepth.UndergroundDirtTop:
				return WorldLocationLibraries.DirtLayerTopTileY;
			case WorldDepth.UndergroundRockTop:
				return WorldLocationLibraries.RockLayerTopTileY;
			case WorldDepth.UnderworldTop:
				return WorldLocationLibraries.UnderworldLayerTopTileY;
			case WorldDepth.Bottom:
				return Main.maxTilesY - 1;
			default:
				return -1;
			}
		}



		////////////////

		[Header( "Regions" )]
		[DrawTicks]
		[JsonConverter( typeof( StringEnumConverter ) )]
		[DefaultValue( WorldDepth.SurfaceTop )]
		public WorldDepth BoundsTopStart {
			get => this._BoundsTopStart;
			set {
				if( (int)value < (int)this._BoundsBottomStart ) {
					this._BoundsTopStart = value;
				}
			}
		}
		private WorldDepth _BoundsTopStart = WorldDepth.SurfaceTop;

		[DrawTicks]
		[JsonConverter( typeof( StringEnumConverter ) )]
		[DefaultValue( WorldDepth.UnderworldTop )]
		public WorldDepth BoundsBottomStart {
			get => this._BoundsBottomStart;
			set {
				if( (int)value > (int)this._BoundsTopStart ) {
					this._BoundsBottomStart = value;
				}
			}
		}
		private WorldDepth _BoundsBottomStart = WorldDepth.UnderworldTop;

		////

		[Range( -4000, 4000 )]
		[DefaultValue( 0 )]
		public int BoundsTopTileOffset { get; set; } = 0;

		[Range( -4000, 4000 )]
		[DefaultValue( 0 )]
		public int BoundsBottomTileOffset { get; set; } = 0;

		////

		[Tooltip( "Percent from the current world region's top to begin at" )]
		[Range( 0f, 1f )]
		[DefaultValue( 0f )]
		public float BoundsTopPercentStart { get; set; } = 0f;

		[Tooltip( "Percent from the current world region's bottom to begin at" )]
		[Range( 0f, 1f )]
		[DefaultValue( 0f )]
		public float BoundsBottomPercentStart { get; set; } = 0f;

		////////////////

		[Range( -8000, 8000 )]
		[DefaultValue( 0 )]
		public int BoundsLeftTileOffset { get; set; } = 0;

		[Range( -8000, 8000 )]
		[DefaultValue( 0 )]
		public int BoundsRightTileOffset { get; set; } = 0;

		////

		[Tooltip( "Percent of world's span to begin the left side of the region upon" )]
		[Range( 0f, 1f )]
		[DefaultValue( 0.35f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float BoundsLeftPercentStart {
			get => this._BoundsLeftPercentStart;
			set {
				if( value < this._BoundsRightPercentStart ) {
					this._BoundsLeftPercentStart = value;
				}
			}
		}
		private float _BoundsLeftPercentStart = 0.35f;

		[Tooltip( "Percent of world's span to begin the right side of the region upon" )]
		[Range( 0f, 1f )]
		[DefaultValue( 0.7f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float BoundsRightPercentStart {
			get => this._BoundsRightPercentStart;
			set {
				if( value > this._BoundsLeftPercentStart ) {
					this._BoundsRightPercentStart = value;
				}
			}
		}
		private float _BoundsRightPercentStart = 0.7f;
	}
}
