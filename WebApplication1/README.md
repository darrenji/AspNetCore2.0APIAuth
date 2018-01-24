> 登录原理

1. 客户端输入用户名和密码，点击"登录"按钮
2. 请求给到了Web API的某个action,这个action的一个功能是产生JWT tokens.
3. action拿着用户信息和数据库比对，如果有这个用户，那就给客户端一个JWT token.
4. 客户端在每次请求的时候都带上这个JWT token.

