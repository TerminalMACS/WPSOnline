# 鉴权
接入在线文档编辑功能时，可以通过js-sdk传递token。

!> 注意！！！如果需要通过js-sdk传递token进行鉴权, 在线文档预览地址的url参数中必须设置`_w_tokentype=1`(注意，这个参数也是需要参与签名的)

```javascript
// 根据自身的业务需求，通过异步请求或者模板输出的方式取得token
var token = 'yourToken'; 
// 设置token
demo.setToken({
  token: token, 
  timeout: 10000 // token超时时间, 可配合refreshToken配置函数使用，当超时前将调用refreshToken
}) 
```

## 超时更新token

可以通过传入获取token函数在token超时的时候自动调用传入函数重新获取token, 可以返回一个promise或者obj

```javascript
// 获取token函数
  const refreshToken = () => {
    // 自身业务处理...

    return {
      token: 'yourToken', // 必需
      timeout: 100000 //  token超时时间 必需
    }
  }
// 配置超时获取token函数
WebOfficeSDK.config({refreshToken})
```

```javascript
// 获取token函数
  const refreshToken = () => {
    // 自身业务处理...

    return Promise.resolve({
      token: 'yourToken', // 必需
      timeout: 100000 //  token超时时间 必需
    })
  }
// 配置超时获取token函数
WebOfficeSDK.config({refreshToken})
```