---
layout: page
title: Koi for DNN 7+
permalink: /dnn
icon: fa-download
order: 2
---

<img src="assets/logos/koi-yinyang-250.png" style="float: right">

What you need to know

1. skins can support Koi without requiring Koi to be installed - [instructions here](dnn-themes)
1. modules using Koi to be multi-framework should include Koi in their distribution package - so read on
1. if you want to play with Koi, install it using the following instructions

## Basics

1. **Installation**: To Install Koi for the .net platform [DNN](http://www.dnnsoftware.com/) just get the latest zip-installation package in the [releases](https://connect-koi.net//releases) and install it like any DNN extension.
1. **Skin/Theme Configuration**: [Just add a koi.json file - follow the instructions here](dnn-themes)

## Including Koi in your Module Distribution

As Koi is not part of DNN distributions, you'll need to include it to be sure everything works. If you include it the correct way, DNN will automatically check if it's already installed, and only install it if your package has a newer version. Here are two examples how to package it:

### Example for Christoc's DNN Module Template

If your module is based on a [Christoc's DNN Module template](https://github.com/ChrisHammond/DNNTemplates), follow these steps to add Koi:

1. Download the [latest release of Koi](https://github.com/DNN-Connect/connect.koi/releases) and unzip it
1. Copy the _/koi_ folder to your modules base folder [your module]
1. Copy the _/bin_ folder to [your module]/koi (the folder copied previously)
1. Prevent the files in the Koi folder from being included in the Resources.zip of your own component. You can do this by modifying the itemgroup named _InstallInclude_. Add `koi\**` to the excluded files list, e.g.: `Exclude="packages\**;koi\**"`
1. Open **Connect_Dnn_Koi.dnn** and copy the **package** node to your own .dnn manifest file
1. Open **ModulePackage.targets** of your module and add the following lines before the comment saying "create the INSTALL RESOURCES.ZIP file":

```xml
    <!-- include koi folder -->
    <ItemGroup>
      <KoiFiles Include="$(MSBuildProjectDirectory)/koi/*.*" Exclude="**\*.dll" />
    </ItemGroup>
    <Copy SourceFiles="@(KoiFiles)" DestinationFolder="$(MSBuildProjectDirectory)\Package\koi\%(RecursiveDir)" />
    <ItemGroup>
      <KoiDllFiles Include="$(MSBuildProjectDirectory)/koi/bin/*.dll" />
    </ItemGroup>
    <Copy SourceFiles="@(KoiDllFiles)" DestinationFolder="$(MSBuildProjectDirectory)\Package\bin" />
```

### Example When Adding Koi Manually

It is possible to manually add Koi to any existing DNN package. Though this is not recommended, it explains what the package must look like after including Koi.

1. Extract the DNN extension
1. Download the [latest release of Koi](https://github.com/DNN-Connect/connect.koi/releases) and unzip it
1. Copy the **/koi** and **/bin** folders from Koi to the extracted files of your extension
1. Open **Connect_Dnn_Koi.dnn** and copy the **package** node to your own .dnn manifest file
1. Zip the files again and test the package