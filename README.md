<img src="assets/koi-wide-medium.png" style="width: 100%">

# Connect.Koi - Styling with multiple CSS Frameworks

Koi is a solution for CMS components to dynamically adjust their output to the CSS-Framework of the current page. In other words, a component can ask the page "what CSS framwork are you using?" and vary the output accordingly.

It currently has an implementation for [DNN/DotNetNuke 7 - 9](https://github.com/dnnsoftware/Dnn.Platform) - see [wiki](https://github.com/DNN-Connect/connect.koi/wiki), and we would appreciate implementations for [Umbraco](https://github.com/umbraco/Umbraco-CMS), [NopCommerce](https://github.com/nopSolutions/nopCommerce), [Orchard](https://github.com/OrchardCMS/Orchard), [OrchardCore](https://github.com/OrchardCMS/OrchardCore) and other .net platforms.

## How to install & use

Depending on your needs or the CMS-Framework you're targeting, you will do different things. All is documented in the [wiki](https://github.com/DNN-Connect/connect.koi/wiki).

## For .net 4.5.1 & .net Core / Standard 2.0 and DNN 7.0+

Koi is built to run with

* .net 4.5.1
* .net Core & Standard 2.0
* DNN 7 / 8 / 9 (as an installable module)

The root project **Koi** with the namespace **Connect.Koi** will compile to .net 4.5.1 and .net Standard 2.0. If you want to contribute an implementation for another CMS, this is where you start.

The testing project **Connect.Testing.Koi** runs unit-tests on Connect.Koi.

The DNN implementation **Connect.Dnn.Koi** extends Koi with the detection mechanisms as they are needed in the platform [DNN / DotNetNuke](http://www.dnnsoftware.com/) and generates an installable ZIP package for DNN 7-9.