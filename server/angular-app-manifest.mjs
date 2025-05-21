
export default {
  bootstrap: () => import('./main.server.mjs').then(m => m.default),
  inlineCriticalCss: true,
  baseHref: '/ViecLamXKLD/',
  locale: undefined,
  routes: [
  {
    "renderMode": 2,
    "route": "/ViecLamXKLD"
  }
],
  entryPointToBrowserMapping: undefined,
  assets: {
    'index.csr.html': {size: 14959, hash: '5661bcbf0196e9a3bf1a8c2910848b01dec81f6b79c106ffc92885d127518332', text: () => import('./assets-chunks/index_csr_html.mjs').then(m => m.default)},
    'index.server.html': {size: 1309, hash: '325bb64f8405501d213ebb608e9b391b93d59095745087ba9cd796903918e556', text: () => import('./assets-chunks/index_server_html.mjs').then(m => m.default)},
    'index.html': {size: 22897, hash: '66ea8ff98f4276880bdd9c24f376e2df28f05a5ad26cd0f0d9643caf4f4b072a', text: () => import('./assets-chunks/index_html.mjs').then(m => m.default)},
    'styles-BYERSX2I.css': {size: 266507, hash: 'F3+lO+p1L/M', text: () => import('./assets-chunks/styles-BYERSX2I_css.mjs').then(m => m.default)}
  },
};
