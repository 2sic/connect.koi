# Connect.Koi - cross CSS Framework styling

Koi is a solution for CMS components to dynamically adjust their output to the CSS-Framework of the current page. In other words, a component can ask the page "what CSS framwork are you using?" and based on that vary the output accordingly.

## How to use

Depending on your needs or the CMS-Framework you're targeting, you will do different things. All is documented in the [wiki](https://github.com/DNN-Connect/connect.koi/wiki). 

## For .net 4.5.1 & .net Core / Standard 2.0 and DNN 7.0+

Koi is built to run with

* .net 4.5.1
* .net Core & Standard 2.0
* DNN 7 / 8 / 9 (as an installable module)

The root project **Koi** with the namespace **Connect.Koi** will compile to .net 4.5.1 and .net Standard 2.0. If you want to contribute an implementation for another CMS, this is where you start.

The testing project **Connect.Testing.Koi** runs unit-tests on Connect.Koi.

The DNN implementation **Connect.Dnn.Koi** extends Koi with the detection mechanisms as they are needed in the platform [DNN / DotNetNuke](http://www.dnnsoftware.com/) and generates an installable ZIP package for DNN 7-9.