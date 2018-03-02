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

## Installing Koi for DNN

To Install Koi for the .net platform [DNN](http://www.dnnsoftware.com/) just get the latest zip-installation package in the [releases](https://connect-koi.net//releases) and install it like any DNN extension.

## Including Koi in your Module Distribution
The procedure of adding Koi to your module distribution differs and depends on how you package your module.

### Christoc's DNN Module template
If your module is based on a current version of [Christoc's DNN Module template](https://github.com/ChrisHammond/DNNTemplates), follow these steps to add Koi:
1. Download the latest version of Koi and unzip it
1. Copy the _/koi_ folder to your modules base folder [your module]
1. Copy the _/bin_ folder to [your module]/koi (the folder copied previously)
1. Open **Connect_Dnn_Koi.dnn** and copy the **package** node to your own .dnn manifest file
1. Open **ModulePackage.targets** of your module and add the following lines before the comment line `create the INSTALL RESOURCES.ZIP file`:
~~~~
	<!-- include koi folder -->
    <ItemGroup>
      <KoiFiles Include="$(MSBuildProjectDirectory)/koi/*.*" Exclude="**\*.dll" />
    </ItemGroup>
    <Copy SourceFiles="@(KoiFiles)" DestinationFolder="$(MSBuildProjectDirectory)\Package\koi\%(RecursiveDir)" />
    <ItemGroup>
      <KoiDllFiles Include="$(MSBuildProjectDirectory)/koi/bin/*.dll" />
    </ItemGroup>
    <Copy SourceFiles="@(KoiDllFiles)" DestinationFolder="$(MSBuildProjectDirectory)\Package\bin" />
~~~~
1. Prevent the files in the Koi folder from being included in the Resources.zip of your component. You can do this by modifying the itemgroup named _InstallInclude_. Add `koi\**` to the excluded files list, e.g.: `Exclude="packages\**;koi\**"`

### Adding Koi manually
It is possible to manually add Koi to a DNN extension. Though this is not recommended, it explains what the package must look like after including Koi.
1. Extract the DNN extension
1. Download the latest version of Koi and unzip it
1. Copy the **/koi** and **/bin** folders from Koi to the extracted files of your extension
1. Open **Connect_Dnn_Koi.dnn** and copy the **package** node to your own .dnn manifest file
1. Zip the files again and test the package