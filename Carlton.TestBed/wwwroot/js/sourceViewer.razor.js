export function highlightCodeBlock() {
    var blocks = document.querySelectorAll('pre code:not(.hljs)');
    Array.prototype.forEach.call(blocks, hljs.highlightBlock);
};

export function getOutputSource() {
    var viewer = document.querySelector(".component-viewer");
    return viewer.innerHTML;
}

export function setOutputMarkup(markup) {
    var block = document.querySelector('.test-component-output-source pre code');
    block.textContent = markup;
}