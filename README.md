# AzurePipelineSample
multi project/module [Azure Pipelines](https://github.com/marketplace/azure-pipelines) sample

|Pipeline|Status|
|:--|:--:|
|master|[![Build Status](https://meilcli.visualstudio.com/AzurePipelineSample/_apis/build/status/MeilCli.AzurePipelineSample?branchName=master)](https://meilcli.visualstudio.com/AzurePipelineSample/_build/latest?definitionId=10&branchName=master)|
|PullRequest(Lib)|[![Build Status](https://meilcli.visualstudio.com/AzurePipelineSample/_apis/build/status/MeilCli.AzurePipelineSample-PR-Lib?branchName=master)](https://meilcli.visualstudio.com/AzurePipelineSample/_build/latest?definitionId=14&branchName=master)|
|PullRequeset(Core)|[![Build Status](https://meilcli.visualstudio.com/AzurePipelineSample/_apis/build/status/MeilCli.AzurePipelineSample-PR-Core?branchName=master)](https://meilcli.visualstudio.com/AzurePipelineSample/_build/latest?definitionId=15&branchName=master)|
|PullRequest(Console)|[![Build Status](https://meilcli.visualstudio.com/AzurePipelineSample/_apis/build/status/MeilCli.AzurePipelineSample-PR?branchName=master)](https://meilcli.visualstudio.com/AzurePipelineSample/_build/latest?definitionId=17&branchName=master)|
|PullRequest|[![Build Status](https://meilcli.visualstudio.com/AzurePipelineSample/_apis/build/status/MeilCli.AzurePipelineSample-PR?branchName=master)](https://meilcli.visualstudio.com/AzurePipelineSample/_build/latest?definitionId=17&branchName=master)|


## Azure Pipeline Settings
- [enable all preview features](https://docs.microsoft.com/ja-jp/azure/devops/project/navigation/preview-features?view=azure-devops)

## Projects
- Lib
  - AzurePipelineSample.NETStandard.Lib
  - AzurePipelineSample.NETStandard.Lib.Test
- Core
  - depends on Lib
  - AzurePipelineSample.NETStandard.Core
  - AzurePipelineSample.NETStandard.Core.Test
- Console
  - depends on Core
  - AzurePipelineSample.NETCore.Console
  - AzurePipelineSample.NETCore.Console.Test

## Pipelines
Sample provides two pull-request pipeline type. Select pipeline type under:
- Allow duplicate build on many pipelines when changing within multi projects
  - pipeline: PullRequest(Lib), yaml: `azure-pipelines-pr-lob.yml`
  - pipeline: PullRequest(Core), yaml: `azure-pipelines-pr-core.yml`
  - pipeline: PullRequest(Console), yaml: `azure-pipelines-pr-console.yml`
- Distribute build on one pipeline when changing within multi projects
  - pipeline: PullRequest, yaml: `azure-pipelines-pr.yml`

Example of changing files, will trigger build:

|Changing|Pipeline|Build Lib|Build Core|Build Console|
|:--|:--|:--:|:--:|:--:|
|Lib files|PullRequest(Lib)|:heavy_check_mark:|||
|Lib files|PullRequest(Core)||||
|Lib files|PullRequest(Console)||||
|Lib files|PullRequest|:heavy_check_mark:|||
|Core files|PullRequest(Lib)||||
|Core files|PullRequest(Core)||:heavy_check_mark:||
|Core files|PullRequest(Console)||||
|Core files|PullRequest||:heavy_check_mark:||
|Console files|PullRequest(Lib)||||
|Console files|PullRequest(Core)||||
|Console files|PullRequest(Console)|||:heavy_check_mark:|
|Console files|PullRequest|||:heavy_check_mark:|
|Lib & Core files|PullRequest(Lib)|:heavy_check_mark:|:heavy_check_mark:||
|Lib & Core files|PullRequest(Core)|:heavy_check_mark:|:heavy_check_mark:||
|Lib & Core files|PullRequest(Console)||||
|Lib & Core files|PullRequest|:heavy_check_mark:|:heavy_check_mark:||
|Core & Console files|PullRequest(Lib)||||
|Core & Console files|PullRequest(Core)||:heavy_check_mark:|:heavy_check_mark:|
|Core & Console files|PullRequest(Console)||:heavy_check_mark:|:heavy_check_mark:|
|Core & Console files|PullRequest||:heavy_check_mark:|:heavy_check_mark:|
|Lib & Core & Console files|PullRequest(Lib)|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|Lib & Core & Console files|PullRequest(Core)|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|Lib & Core & Console files|PullRequest(Console)|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|Lib & Core & Console files|PullRequest|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|

This dupplicate build is happened by path trigger priority between 'include' and 'exclude'.