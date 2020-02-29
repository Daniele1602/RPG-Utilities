using System;
namespace RPGUtilities.Attributes {
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
	public class Salable : Attribute {

		public readonly int price;
		public Salable(int price) {
			this.price = price;
		}
	}
}