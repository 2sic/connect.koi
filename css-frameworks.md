---
layout: page
title: CSS Frameworks
permalink: /css-frameworks
icon: fa-css3
order: 9
---

<img src="assets/logos/koi-yinyang-250.png" style="float: right">

# CSS Framework Codes

This is the full list of CSS-Framework codes. Please use only these in published material. 

_If you need a CSS Framework which is not yet listed here, please suggest it in a [new issue](/DNN-Connect/connect.koi/issues/new) - we'll evaluate it according to our [rules to adding css-framework codes](#rules-for-adding-css-frameworks)._

## CSS Frameworks and their Unique Koi Codes

* `all` reserved to mark things that apply to all frameworks
* `bs3` [Bootstrap 3](https://getbootstrap.com/docs/3.3/) - download [koi.json](koi.json/bs3/koi.json)
* `bs4` [Bootstrap 4](https://getbootstrap.com/) - download [koi.json](koi.json/bs4/koi.json)
* `bs*` Bootstrap future releases
* `fnd6` [Foundation 6](https://foundation.zurb.com/) - download [koi.json](koi.json/fnd6/koi.json)
* `fnd*` Foundation future releases
* `fto*` reserved for-testing-only
* `oth` reserved
* `mtz1` [Materialize 1](http://materializecss.com/) - download [koi.json](koi.json/mtz1/koi.json)
* `mtz*` Materialize future releases
* `smt2` [Semantic UI 2](https://semantic-ui.com/) - download [koi.json](koi.json/smt2/koi.json)
* `smt*` Semantic UI future releases
* `uik2` [UI Kit 2](https://getuikit.com/v2/) - download [koi.json](koi.json/uik2/koi.json)
* `uik3` [UI Kit 3](https://getuikit.com/)
* `uik*` UI Kit future releases
* `unk` reserved to mark things that apply when the framework isn't known

## Rules for Adding CSS-Frameworks

These are the general rules we use to manage CSS Framework codes:

1. CSS frameworks must be public (so no private frameworks in the public standard)
1. The framework must still be actively maintained - so dead framework like YAML, Skeleton or 960gs will not be added, as we don't expect new components to be created for these frameworks
1. CSS frameworks must have a minimal user base to be added
    1. at least a few thousand sites across the internet
    1. or at least a few thousand stars on Github
    1. or at least 100 sites in one of the primary Koi-supported platforms like DNN

## CSS Frameworks Regarded as Dead

The following CSS frameworks appear dead and not actively maintained any more, so were explicitly not added to the standard list of CSS frameworks:

* [YAML](http://www.yaml.de/)
* 1140 Grid
* 960gs
* Skelleton
* YUI

## FAQ

### How to use Koi with private CSS frameworks?

You can always use your own code. Let's say you have your company internal CSS-Framework called **Blast**. You can just make up a code for it - like `blst` and use that in your `koi.json` and in your code. Prefer longer codes, because others may some day clash with a public code, like `bs1` would eventually clash with **Bootstrap**.

The public codes will always be 2-3 characters + version number, so use something different and you'll be safe.
### How to Use Koi if a public framework code is not yet standard?

If the public framework has a minimum adoption according to the [rules](css-framework-codes#rules-for-adding-css-frameworks), please post an issue. Otherwise, please make up a code which likely would become the standard and work with that, until it becomes standardized.
