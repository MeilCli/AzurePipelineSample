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
    - Build Lib, Build Core, Test Lib
  - pipeline: PullRequest(Core), yaml: `azure-pipelines-pr-core.yml`
    - Build Lib, Build Core, Build Console, Test Core
  - pipeline: PullRequest(Console), yaml: `azure-pipelines-pr-console.yml`
    - Build Lib, Build Core, Build Console, Test Console
- Distribute build on one pipeline when changing within multi projects
  - pipeline: PullRequest, yaml: `azure-pipelines-pr.yml`

Example of changing files, will trigger build:

|Changing|Run PullRequest(Lib)|Run PullRequest(Core)|Run PullRequest(Console)|
|:--|:--:|:--:|:--:|
|Lib files|:heavy_check_mark:|||
|Core files||:heavy_check_mark:||
|Console files|||:heavy_check_mark:|
|Lib & Core files|:heavy_check_mark:|:heavy_check_mark:||
|Core & Console files||:heavy_check_mark:|:heavy_check_mark:
|Lib & Core & Console files|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|

This dupplicate build is happened by path trigger priority between `include` and `exclude`.

PullRequest pipeline will trigger build:

|Changing|Build Lib|Build Core|Build Console|Test Lib|Test core|Test Console|
|:--|:--:|:--:|:--:|:--:|:--:|:--:|
|Lib files|:heavy_check_mark:|:heavy_check_mark:||:heavy_check_mark:|||
|Core files|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:||:heavy_check_mark:||
|Console files|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|||:heavy_check_mark:|
|Lib & Core files|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:||
|Core & Console files|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:||:heavy_check_mark:|:heavy_check_mark:|
|Lib & Core & Console files|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|