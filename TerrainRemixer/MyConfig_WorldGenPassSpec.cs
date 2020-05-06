using System;
using System.ComponentModel;
using Terraria;
using Terraria.ModLoader.Config;
using HamstarHelpers.Classes.Tiles.TilePattern;


namespace TerrainRemixer {
	public partial class TerrainRemixerGenPassSpec {
		public TilePatternConfig Filter { get; set; }


		////

		[Range( 0.0001f, 1f )]
		[DefaultValue( 0.01f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float Scale { get; set; }


		////

		[Range( 0f, 1f )]
		[DefaultValue( 0.5f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float NoiseValueMinimumForSolidTile { get; set; } = 0.5f;


		////

		[Range( 0f, 1f )]
		[DefaultValue( 0.25f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float VerticalDistancePercentFromCenterBeforeBlending { get; set; } = 0.25f;

		[Range( 0f, 1f )]
		[DefaultValue( 0.25f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float HorizontalDistancePercentFromCenterBeforeBlending { get; set; } = 0.25f;



		////////////////

		/*public override bool Equals( object obj ) {
			return base.Equals( obj );
		}

		public override int GetHashCode() {
			return base.GetHashCode();
		}*/
	}
}
