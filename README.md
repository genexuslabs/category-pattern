# GeneXus Category Pattern
⚠️ This repo is not longer under development.

Here you can find the source of the Category pattern, a GeneXus pattern that was part of it until first upgrades of its version 17.

## Requirements
- Build Tools for Visual Studio 2019
- [GeneXus Platform SDK 17 Upgrade 4](https://www.genexus.com/en/developers/downloadcenter?data=5924)

## Build & Deploy
`workflows.build` is defined to simplify the Build and Deploy operations.

| Target | Description |
| --- | --- |
| `Build` | Builds the entire pattern for the specified configuration. This target is configured as the default one, it can be omitted at the command-line. |
| `Deploy` | Copies the pattern files to the directory specified by `GXInstall` variable. |

Usage samples:
- Builds the pattern with Configuration=Debug

`c:repo\category-pattern>msbuild workflows.build /p:GX_SDK_DIR="c:\mySDK\\"`

- Builds the pattern with Configuration=Release

`c:repo\category-pattern>msbuild workflows.build /t:Build /p:Configuration=Release;GX_SDK_DIR="c:\mySDK\\"`

- Deploys pattern files to the specified GeneXus installation

`c:repo\category-pattern>msbuild workflows.build /t:Deploy /p:GXInstall="c:\myGX17"`

### MSBuild variables

| Name | Description |
| --- | --- |
| `Configuration` | Specifies the configuration. `Release` is the default value. Valid configurations: `Debug` or `Release`. |
| `GXInstall` | Path to a GeneXus installation where you want to test the Category pattern. If it is not specified, the deployed files are copied to the directory `.gxinstall`. |
| `GX_SDK_DIR` | Path to a GeneXus SDK installation. |

## Documentation
Please, go to our [Wiki](https://wiki.genexus.com/commwiki/servlet/wiki?5752,Category%20Pattern) for detailed information about this pattern usage.
