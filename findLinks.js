const links = Array.from(document.querySelectorAll('a'));
links.forEach(link => {
  console.log(`Texto: ${link.textContent}, Href: ${link.href}`);
});
