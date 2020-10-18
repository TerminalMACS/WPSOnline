# 关于兼容性
`js-sdk`的兼容浏览器版本如下:

| 平台 | 支持浏览器 |
|---|---|
|iOS | Safari，QQ内置浏览器，QQ小程序，微信内置浏览器，微信小程序 |
|Android | QQ内置浏览器，QQ小程序，微信内置浏览器，微信小程序 |
|Windows | Chrome、QQ浏览器(非兼容模式)、EDGE、火狐、 IE11(只保证打开预览、不保证编辑功能完全兼容)|
|Mac OSX | Chrome、Safari、QQ浏览器、EDGE、火狐 | 

> 原则上会定期更新适配各平台的主流浏览器最新版本

!> 注意，js-sdk不包含promise-polyfill, 如果需要兼容没有内置Promise对象的低版本浏览器(例如IE11)， 则需要在js-sdk之前引入promise polyfill。

```html
<script src="//unpkg.com/promise-polyfill@8.1.3/dist/polyfill.min.js"></script>
```