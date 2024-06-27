function testMethod(){
const h1Content = document.querySelector('h1').innerHTML;

if (h1Content === "Hello, World!") {
    alert("The content of the h1 element is 'Hello World'");
} else {
    alert("The content of the h1 element is not 'Hello World'");
}
}