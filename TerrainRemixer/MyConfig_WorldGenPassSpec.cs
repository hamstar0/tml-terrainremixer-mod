using System;
using System.ComponentModel;
using Terraria;
using Terraria.ModLoader.Config;


namespace TerrainRemixer {
	public partial class TerrainRemixerGenPassSpec {
		//public TilePatternConfig Filter { get; set; }


		////

		[Tooltip( "\"Scale\" value given to the noise algorithm. \nSmaller = more dramatic." )]
		[Range( 0.0001f, 1f )]
		[DefaultValue( 0.01f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float NoiseScale { get; set; }


		////

		[Tooltip( "Minimum value range to select from noise ouput per tile to decide if it's smaller. \nSmaller = less terrain." )]
		[Range( 0f, 1f )]
		[DefaultValue( 0.5f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float NoiseValueMinimumForSolidTile { get; set; } = 0.15f;


		////

		[Tooltip( "Percent of vertical distance from region's center before blending starts." )]
		[Range( 0f, 1f )]
		[DefaultValue( 0.25f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float VerticalDistancePercentFromCenterBeforeBlending { get; set; } = 0.15f;

		[Tooltip( "Percent of horizontal distance from region's center before blending starts." )]
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
