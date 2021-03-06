# GeneXus Category Pattern
⚠️ This repo is no longer under development.

Here you can find the source of the Category pattern, a GeneXus pattern that was part of it until first upgrades of its version 17.

## Requirements
- Build Tools for Visual Studio 2019
- [GeneXus Platform SDK 17 Upgrade 4](https://www.genexus.com/en/developers/downloadcenter?data=5924)

## Build & Deploy
[`workflows.msbuild`](workflows.msbuild) is defined to simplify the Build and Deploy operations.

| Target | Description |
| --- | --- |
| `Build` | Builds the entire pattern for the specified configuration. This target is configured as the default one, it can be omitted at the command-line. |
| `Deploy` | Copies the pattern files to the directory specified by `GX_PROGRAM_DIR` variable. |

Usage samples:
- Builds the pattern with Configuration=Debug and a specified GeneXus SDK installation:

`c:repo\category-pattern>msbuild workflows.msbuild /p:GX_SDK_DIR="c:\mySDK"`

- Builds the pattern with Configuration=Release, GX_SDK_DIR can be omitted if an environment variable with this name is already defined:

`c:repo\category-pattern>msbuild workflows.msbuild /t:Build /p:Configuration=Release`

- Deploys pattern files to the specified GeneXus installation:

`c:repo\category-pattern>msbuild workflows.msbuild /t:Deploy /p:GX_PROGRAM_DIR="c:\myGX17\\"`

### MSBuild variables

| Name | Description |
| --- | --- |
| `Configuration` | Specifies the configuration. `Debug` is the default value. Valid configurations: `Debug` or `Release`. |
| `GX_PROGRAM_DIR` | Path to a GeneXus installation; this value can be omitted. If an environment value with this name is already defined it is used by default. Otherwise, `Build` target uses a default value calculated from `GX_SDK_DIR` and `Deploy` target uses a relative directory '.gxinstall'. |
| `GX_SDK_DIR` | Path to a GeneXus SDK installation; this value can be omitted if an environment variable is defined. *Required for `Build` target and build the solution.* |

## Documentation
Please, go to our [Wiki](https://wiki.genexus.com/commwiki/servlet/wiki?5752,Category%20Pattern) for detailed information about this pattern usage.
