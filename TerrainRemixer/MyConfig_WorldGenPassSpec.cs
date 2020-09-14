using System;
using System.ComponentModel;
using Terraria;
using Terraria.ModLoader.Config;
using HamstarHelpers.Classes.Tiles.TilePattern;


namespace TerrainRemixer {
	public partial class TerrainRemixerGenPassSpec {
		public TilePatternConfig Filter { get; set; } = new TilePatternConfig(
			new TilePatternBuilder { IsActive = true }
		);


		////

		[Tooltip( "\"Scale\" value given to the noise algorithm. \nSmaller = more dramatic." )]
		[Range( 0.0001f, 1f )]
		[DefaultValue( 0.01f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float NoiseScale { get; set; } = 0.01f;


		////

		[Tooltip( "Minimum value range of noise ouput per tile before it is removed. \nSmaller = thicker terrain." )]
		[Range( 0f, 1f )]
		[DefaultValue( 0.5f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float NoiseValueMinimumUntilTileRemoval { get; set; } = 0.5f;


		////

		[Tooltip( "Percent of vertical distance from region's center before blending starts." )]
		[Range( 0f, 1f )]
		[DefaultValue( 0.7f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float VerticalDistancePercentFromCenterBeforeBlending { get; set; } = 0.7f;

		[Tooltip( "Percent of horizontal distance from region's center before blending starts." )]
		[Range( 0f, 1f )]
		[DefaultValue( 0.7f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float HorizontalDistancePercentFromCenterBeforeBlending { get; set; } = 0.7f;



		////////////////

		/*public override bool Equals( object obj ) {
			return base.Equals( obj );
		}

		public override int GetHashCode() {
			return base.GetHashCode();
		}*/
	}
}
