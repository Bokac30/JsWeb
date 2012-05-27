function human (obj) {
	this.name = obj.name;
	this.age = obj.age;
	this.gender = obj.gender;
}

function generateData (num) {
	var arr = [];
	for(var i = 0; i < num; i++) {
		var p = new human({
			name: 'John' + i,
			age: i
		});
		
		arr.push(p);
	}
	return arr;
}

function vm () {
	this.title = ko.observable();
	
}

function onLoad() {
	var data = generateData(60);
	document.getElementById('results').innerHTML = data;
}



window.onload = onload;