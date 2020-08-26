export const environment = {
  production: false,
  application: {
    name: 'Dynamic',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44389',
    clientId: 'Dynamic_ConsoleTestApp',
    dummyClientSecret: '1q2w3e*',
    scope: 'Dynamic',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44389',
    },
    Dynamic: {
      url: 'https://localhost:44380',
    },
  },
};
