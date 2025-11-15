// Um service worker simples para permitir que o app seja "instalável" (PWA)
// e funcionar offline (se for um app Blazor WebAssembly).
// Para Blazor Server, o principal benefício é habilitar a instalação.

self.addEventListener('fetch', function(event) {
  // Para Blazor Server, nós apenas passamos a requisição para a rede.
  event.respondWith(fetch(event.request));
});

self.addEventListener('install', event => {
  console.log('Service worker instalando...');
  self.skipWaiting();
});

self.addEventListener('activate', event => {
  console.log('Service worker ativando...');
});