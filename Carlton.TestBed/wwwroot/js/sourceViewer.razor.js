export function postRender(usage) {
    var outputSource = getOutputSource();
    setOutputMarkup(outputSource);
    setUsageMarkup(usage);
    highlightCodeBlock();
}

export function getOutputSource() {
    var viewer = document.querySelector(".component-viewer");
    var markup = viewer.innerHTML;
    markup = markup.replaceAll("<!--!-->", "");
    markup = markup.replaceAll(/\n/g, "");
    return format(markup);
}

function setOutputMarkup(markup) {
    var block = document.querySelector('.test-component-output-source pre code');
    block.textContent = markup;
}

function setUsageMarkup(markup) {
    var block = document.querySelector('.test-component-usage pre code');
    block.textContent = markup;
}

function highlightCodeBlock() {
    var blocks = document.querySelectorAll('pre code');
    Array.prototype.forEach.call(blocks, hljs.highlightBlock);
};

function format(html) {
    var tab = '\t';
    var result = '';
    var indent = '';

    html.split(/>\s*</).forEach(function (element) {
        if (element.match(/^\/\w/)) {
            indent = indent.substring(tab.length);
        }

        result += indent + '<' + element + '>\r\n';

        if (element.match(/^<?\w[^>]*[^\/]$/) && !element.startsWith("input")) {
            indent += tab;
        }
    });

    return result.substring(1, result.length - 3);
}

