using System;
using Artech.Architecture.Common.Objects;
using Artech.Genexus.Common.Objects;
using Artech.Packages.Patterns;
using Artech.Packages.Patterns.Custom;
using Artech.Packages.Patterns.Objects;
using Artech.Packages.Patterns.Definition;

[assembly: PatternImplementation(typeof(Artech.Patterns.Category.CategoryPattern))]

namespace Artech.Patterns.Category
{
	public class CategoryPattern : PatternImplementation
	{
		public static Guid Id
		{
			get { return new Guid("7060F06D-C463-43ab-A208-A9385E2A6895"); }
		}

		public static PatternDefinition Definition
		{
			get { return PatternEngine.GetPatternDefinition(Id); }
		}

		public override IDefaultInstanceGenerator GetInstanceGenerator()
		{
			return new CategoryInstanceGenerator();
		}

		public override IPatternBuildProcess GetBuildProcess()
		{
			return new CategoryBuildProcess();
		}


	}
}
