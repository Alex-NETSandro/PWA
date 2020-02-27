const menu = ['Post', 'Author', 'Category'];
const carregar = function () {
    const nav = document.querySelector('nav')
    const div = document.createElement('div');
    const img = document.createElement('img');
    const ul = document.createElement('ul');
    nav.appendChild(div);
    div.appendChild(img);
    nav.appendChild(ul);
    img.setAttribute('src', '~/imgBlog.jpg');
    createTag(ul);

}
const createTag = function (ul) {
    for (var i = 0; i < menu.length; i++) {
        const a = document.createElement('a');
        const li = document.createElement('li')
        ul.appendChild(a);
        a.appendChild(li);
        a.setAttribute('href', `#${menu[i]}`);
        li.innerHTML = menu[i];
    }
}
