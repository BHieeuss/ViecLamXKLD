
export default {
  bootstrap: () => import('./main.server.mjs').then(m => m.default),
  inlineCriticalCss: true,
  baseHref: '/',
  locale: undefined,
  routes: [
  {
    "renderMode": 2,
    "route": "/"
  }
],
  entryPointToBrowserMapping: undefined,
  assets: {
    'index.csr.html': {size: 342489, hash: '0c805e8064f599a73a2385b21f626e7642f52d0f0c31b402c3478fb8e6ad7e1b', text: () => import('./assets-chunks/index_csr_html.mjs').then(m => m.default)},
    'index.server.html': {size: 328845, hash: '51f3de7cefc3b302111928fac9017d4368115dbf9453d8bd0af6b0fdd4792c68', text: () => import('./assets-chunks/index_server_html.mjs').then(m => m.default)},
    'index.html': {size: 399816, hash: '462cf82fe35d5f2d5b487fe20f838400825beba395edf0d3f0555d12efb6c0d8', text: () => import('./assets-chunks/index_html.mjs').then(m => m.default)},
    'styles-NS5MKKDP.css': {size: 257274, hash: 'jzRUQRfxZ+Y', text: () => import('./assets-chunks/styles-NS5MKKDP_css.mjs').then(m => m.default)}
  },
};
