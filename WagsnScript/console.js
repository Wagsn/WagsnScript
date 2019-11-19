console.log(console);
console.log("hello word");
console.log("pi: "+pi)
console.log(pi + 10)
function hello() {
    console.log("function hello")
}
hello()
console.log("hello: " + hello);

class Person {
    constructor() {
        this.age = 18;
        this.sex = true;
        this.name = "Wagsn";
    }
}
console.log("class Person: " + Person);
console.log("object Person: " + new Person());
console.log("function version: " + version);
console.log("jsEngineVersion: " + version());
console.log("math.max: " + math.max);
console.log("E:\WorkSpace\DotNET\WagsnScriptSln\README.md: " + file.read("E:/WorkSpace/DotNET/WagsnScriptSln/README.md"))
console.log("E:\WorkSpace\DotNET\WagsnScriptSln\README.md: " + file.load("E:/WorkSpace/DotNET/WagsnScriptSln/README.md"))
