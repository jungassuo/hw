const { createProxyMiddleware } = require('http-proxy-middleware');

const onError = (err, req, resp, target) => {
    console.error(`${err.message}`);
}

module.exports = function (app) {
  //Product api proxy
  const productProxy = createProxyMiddleware("/api/product", {
    proxyTimeout: 10000,
    target: "https://localhost:7133",
    // Handle errors to prevent the proxy middleware from crashing when
    // the ASP NET Core webserver is unavailable
    onError: onError,
    secure: false,
    // Uncomment this line to add support for proxying websockets
    //ws: true, 
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  const orderProxy = createProxyMiddleware("/api/order", {
    proxyTimeout: 10000,
    target: "https://localhost:7118",
    // Handle errors to prevent the proxy middleware from crashing when
    // the ASP NET Core webserver is unavailable
    onError: onError,
    secure: false,
    // Uncomment this line to add support for proxying websockets
    //ws: true, 
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  //Topping api proxy
  const toppingProxy = createProxyMiddleware("/api/topping", {
    proxyTimeout: 10000,
    target: "https://localhost:7130",
    // Handle errors to prevent the proxy middleware from crashing when
    // the ASP NET Core webserver is unavailable
    onError: onError,
    secure: false,
    // Uncomment this line to add support for proxying websockets
    //ws: true, 
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  app.use(productProxy)
  app.use(toppingProxy)
  app.use(orderProxy)
};
