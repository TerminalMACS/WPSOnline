# 下载
以下是js-sdk发布记录
_____
## Release v1.1.5

资源:  [web-office-sdk-v1.1.5-bdbc072a.zip](https://js.cache.openplatform.wpscdn.cn/sdk/web-office-sdk-v1.1.5-bdbc072a.zip)

- 【feature】PC_全屏方式控制配置：iframe内全屏以及浏览器内全屏。
- 【fix】修复setter的callback问题。

## Release v1.1.4

资源:  [web-office-sdk-v1.1.4-e19c61b.zip](https://js.cache.openplatform.wpscdn.cn/sdk/web-office-sdk-v1.1.4-e19c61b.zip)

- feat-新增 【演示】评论入口commandbarId。
- feat-新增 事件解绑API，通过off方法解绑on方法的绑定的事件。
- feat-新增 fullscreenchange（进入或退出全屏）事件。
- fix- 修复refreshToken错误过一次下次不触发问题。

## Release v1.1.3

资源:  [web-office-sdk-v1.1.3-9864b8e.zip](https://js.cache.openplatform.wpscdn.cn/sdk/web-office-sdk-v1.1.3-9864b8e.zip)

1. 新增缩放控制API。
2. 新增PPT全屏播放时隐藏toolbar配置项。
3. 新增自定义toast API，可以替换成自己定制的toast。
4. 【移动端】【文字】【演示】新增直接进入编辑模式配置。
5. 【pc】【文字】【演示】【PDF】支持隐藏底部状态栏配置。
6. 【文字】新增控制隐藏显示“目录”API。
7. 【文字】新增控制隐藏显示“评论”API。

## Release v1.1.2

资源:  [web-office-sdk-v1.1.2-063052e.zip](http://js3.cache.weboffice.wpsgo.com/wwo/sdk/web-office-sdk-v1.1.2-063052e.zip)

- feat- 支持更多的组件状态设置。
- feat- 新增获取、切换头部tab接口和事件回调。
- feat- 新增错误事件。
- feat-【演示】新增上一步、下一步接口和事件回调。
- feat-【演示】新增播放状态切换接口和事件回调。
- feat-【PDF】新增单页模式切换接口。
- feat-【文字】新增书签功能接口（列表、新增、删除、跳转）。
- feat-【文字】新增获取修订记录接口。
- feat-【文字】新增获取评论接口。
- fix-修复`save()`方法失效问题。

## Release v1.1.1 

资源:  [web-office-sdk-v1.1.1-a06b0eb.zip](http://js3.cache.weboffice.wpsgo.com/wwo/sdk/web-office-sdk-v1.1.1-a06b0eb.zip)

- fix: 修复偶现api调用时序错乱问题。 
- feat: 没有配置mount默认占满全屏 
- fix: 单个接口调用catch()不生效问题 
- feat: updateConfig() 方法兼容处理，该函数即将废弃。 
- fix: 修复重复调用config时文档类型没更新问题。 
- fix: 修复事件回调顺序问题 

## Release v1.1.0 

资源:  [web-office-sdk-1.1.0.zip](http://js3.cache.weboffice.wpsgo.com/wwo/sdk/web-office-sdk-1.1.0.zip)

- feat: 添加wps配置对应的接口声明 
- fix: 修复WordApplication、PPTApplication、PDFApplication等对象丢失问题 
- fix: 修复错误中断时,下次调用api无法发送消息问题
