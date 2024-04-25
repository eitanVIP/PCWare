//Setup
const canvas = document.getElementById("GameCanvas");
const ctx = canvas.getContext("2d");
canvas.width = innerWidth * 0.979;
canvas.height = innerHeight - 255;



//Consts
const width = canvas.width;
const height = canvas.height;
const halfWidth = canvas.width / 2;
const halfHeight = canvas.height / 2;
const fps = 60;
const dt = 1 / fps;



//Classes
class Vector {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    getMagnitude() {
        return Math.sqrt(Math.pow(this.x, 2) + Math.pow(this.y, 2));
    }

    Add(b) {
        let c = new Vector(this.x + b.x, this.y + b.y)
        return c;
    }

    Sub(b) {
        let c = this.Add(new Vector(-b.x, -b.y));
        return c;
    }

    Close(b, threshold) {
        let c = this.Sub(b);
        let dist = c.getMagnitude();
        return dist <= threshold;
    }

    Copy() {
        return new Vector(this.x, this.y);
    }

    Equals(b) {
        return this.x == b.x && this.y == b.y;
    }
}

class Object {
    constructor(Pos, Rot, Scale, Img) {
        this.Pos = Pos;
        this.Rot = Rot;
        this.Img = new Image(Scale.x, Scale.y);
        this.Img.src = Img;
    }

    Rotate(a) {
        this.Rot += a;
    }

    Move(vec) {
        this.Pos = this.Pos.Add(vec);
    }

    Scale(vec) {
        this.Img.width = vec.x;
        this.Img.height = vec.y;
    }

    getScale() {
        return new Vector(this.Img.width, this.Img.height);
    }

    changeImage(Img) {
        this.Img.src = Img;
    }

    collisionPoint(point) {
        return point.x >= this.Pos.x - this.getScale().x / 2 && point.x <= this.Pos.x + this.getScale().x / 2 &&
            point.y >= this.Pos.y - this.getScale().y / 2 && point.y <= this.Pos.y + this.getScale().y / 2;
    }

    Draw() {
        ctx.drawImage(this.Img, halfWidth + this.Pos.x - this.getScale().x / 2, halfHeight - this.Pos.y - this.getScale().y / 2, this.getScale().x, this.getScale().y);
    }
}

class DragableObject extends Object {
    constructor(Pos, Rot, Scale, Img) {
        super(Pos, Rot, Scale, Img)

        this.canDrag = true;
        this.isDragging = false;
        this.offsetX, this.offsetY;

        canvas.addEventListener('mousedown', (e) => {
            var mousePos = GetMousePos(e);

            if (this.collisionPoint(mousePos)) {
                this.isDragging = true;
                this.offsetX = mousePos.x - this.Pos.x;
                this.offsetY = mousePos.y - this.Pos.y;
            }
        });

        canvas.addEventListener('mousemove', (e) => {
            var mousePos = GetMousePos(e);

            if (this.isDragging && this.canDrag) {
                this.Pos.x = mousePos.x - this.offsetX;
                this.Pos.y = mousePos.y - this.offsetY;
            }
        });

        canvas.addEventListener('mouseup', (e) => {
            this.isDragging = false;
        });
    }
}

class PCItem extends DragableObject {
    constructor(Start, Target, targetScale, Scale, Img) {
        super(Start.Copy(), 0, Scale, Img);

        canvas.addEventListener('mouseup', (e) => {
            if (!this.Pos.Equals(Target)) {
                if (this.Pos.Close(Target, Scale.x / 2)) {
                    this.Pos = Target.Copy();
                    this.Scale(targetScale);
                    this.canDrag = false;
                    Correct();
                }
                else if (!this.Pos.Equals(Start)) {
                    this.Pos = Start.Copy();
                    Wrong();
                }
            }

            console.log(this.Pos.Equals(this.Start));
        });
    }
}



//Objects
let space = 25;
let size = 100;

var Case = new Object(new Vector(0, 75), 0, new Vector(550, 550), "../Images/Case3.png");

var Motherboard = new PCItem(new Vector(0  * (space + size) - (10 * (space + size) + size / 2) / 2 + space, -halfHeight + size / 2 + space), new Vector(-40, 100), new Vector(300, 300), new Vector(size, size), "../Images/Motherboard.png");
var CPU         = new PCItem(new Vector(1  * (space + size) - (10 * (space + size) + size / 2) / 2 + space, -halfHeight + size / 2 + space), new Vector(-51, 172), new Vector(100, 100), new Vector(size, size), "../Images/CPU.png");
var RAM         = new PCItem(new Vector(2  * (space + size) - (10 * (space + size) + size / 2) / 2 + space, -halfHeight + size / 2 + space), new Vector(44, 148), new Vector(100, 100), new Vector(size, size), "../Images/RAM3.png");
var SSD         = new PCItem(new Vector(3  * (space + size) - (10 * (space + size) + size / 2) / 2 + space, -halfHeight + size / 2 + space), new Vector(-58, 0), new Vector(50, 50), new Vector(size, size), "../Images/SSD.png");
var HDD         = new PCItem(new Vector(4  * (space + size) - (10 * (space + size) + size / 2) / 2 + space, -halfHeight + size / 2 + space), new Vector(82, 37), new Vector(150, 150), new Vector(size, size), "../Images/HDD.png");
var GPU         = new PCItem(new Vector(5  * (space + size) - (10 * (space + size) + size / 2) / 2 + space, -halfHeight + size / 2 + space), new Vector(-58, 50), new Vector(250, 150), new Vector(size, size), "../Images/GPU.png");
var PSU         = new PCItem(new Vector(6  * (space + size) - (10 * (space + size) + size / 2) / 2 + space, -halfHeight + size / 2 + space), new Vector(-107, -77), new Vector(125, 125), new Vector(size, size), "../Images/PSU.png");
var Fan1        = new PCItem(new Vector(7  * (space + size) - (10 * (space + size) + size / 2) / 2 + space, -halfHeight + size / 2 + space), new Vector(-184, 200), new Vector(100, 100), new Vector(size, size), "../Images/Fan.png");
var Fan2        = new PCItem(new Vector(8  * (space + size) - (10 * (space + size) + size / 2) / 2 + space, -halfHeight + size / 2 + space), new Vector(202, 200), new Vector(100, 100), new Vector(size, size), "../Images/Fan.png");
var Fan3        = new PCItem(new Vector(9  * (space + size) - (10 * (space + size) + size / 2) / 2 + space, -halfHeight + size / 2 + space), new Vector(202, 75), new Vector(100, 100), new Vector(size, size), "../Images/Fan.png");
var Fan4        = new PCItem(new Vector(10 * (space + size) - (10 * (space + size) + size / 2) / 2 + space, -halfHeight + size / 2 + space), new Vector(202, -50), new Vector(100, 100), new Vector(size, size), "../Images/Fan.png");

var Objects = [Case, Motherboard, CPU, RAM, SSD, HDD, GPU, PSU, Fan1, Fan2, Fan3, Fan4];



//Functions
setInterval(MainLoop, 1000.0 / fps);

function MainLoop() {
    Clear();

    Objects.forEach((obj) => { obj.Draw(); });
}

function Clear() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
}

function GetMousePos(e) {
    return new Vector(e.clientX - canvas.getBoundingClientRect().left - halfWidth,
        halfHeight - e.clientY + canvas.getBoundingClientRect().top);
}

function Wrong() {
    var snd = new Audio("../Sounds/Wrong.mp3");
    snd.volume = 1;
    snd.play();
}

function Correct() {
    var snd = new Audio("../Sounds/Correct.mp3");
    snd.volume = 1;
    snd.play();
}