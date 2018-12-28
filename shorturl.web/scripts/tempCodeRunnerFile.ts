interface IA {
    hi()
    name
}
class A implements IA {
    public name : string
    /**
     * print hello world
     */
    public hi: any = () => {
        console.log(name + " hi")
    }
    public say(){
        console.log("i am " + this.name);
    }
    constructor(iname:string){
        this.name=iname
    }
}
class B extends A {
    constructor(iname:string){
        super(iname)
    }
    public hi = () => {
        super.say()
    }
}
const b = new B("tom");
b.hi();