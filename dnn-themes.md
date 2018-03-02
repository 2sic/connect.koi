---
layout: page
title: DNN themes/skins
permalink: /dnn-themes
icon: fa-cog
order: 3
---

<img src="assets/logos/koi-yinyang-250.png" style="float: right">

Skins must broadcast what CSS framework they use. This does not require Koi to be installed. Simply add a **koi.json** configuration file into the skin/theme folder. As this has no side-effects, we urge all skin/theme makers to include the appropriate koi.json. This is a sample **koi.json** for Bootstrap 3:

```json
{
  "default": {
    "cssFramework": "bs3"
  }
}
```

## CSS Framework Codes & Downloads

These codes are standardized so that theme-developers use the same keys to identify CSS frameworks. These are the most widespread frameworks as of now:

* `bs3` [Bootstrap 3](https://getbootstrap.com/docs/3.3/) - download [koi.json](koi.json/bs3/koi.json)
* `bs4` [Bootstrap 4](https://getbootstrap.com/) - download [koi.json](koi.json/bs4/koi.json)
* `fnd6` [Foundation 6](https://foundation.zurb.com/) - download [koi.json](koi.json/fnd6/koi.json)
* `mtz1` [Materialize 1](http://materializecss.com/) - download [koi.json](koi.json/mtz1/koi.json)
* `smt2` [Semantic UI 2](https://semantic-ui.com/) - download [koi.json](koi.json/smt2/koi.json)
* `uik2` [UI Kit 2](https://getuikit.com/v2/) - download [koi.json](koi.json/uik2/koi.json)

Review the [full list of css framework codes](css-frameworks) for more.