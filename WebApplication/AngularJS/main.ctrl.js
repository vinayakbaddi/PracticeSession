//Before we can use the controller we need to tell angular which part of our HTML document this controller has governance over. You can have many controllers per document and many controllers governing the same section of a document, you can even have nested controllers. 
angular.module('app').controller('MainController', function () {
    var vm = this; // ViewModel
    vm.title = "Angular JS Working Example, maddY";
    vm.searchInput = "";
    vm.shows = [
        {
            title: "Shawshank redemption",
            year: 1999,
            favorite: true
        },
        {
            title: "Dark Knight returns",
            year: 2007,
            favourite: true
        },
        {
            title: "Iron Man",
            year: 2009,
            favourite: true
        }
    ];

    vm.orders = [
    {
        id: 1,
        title: 'Year Ascending',
        key: 'year',
        reverse: false
    },
    {
        id: 2,
        title: 'Year Descending',
        key: 'year',
        reverse: true
    },
    {
        id: 3,
        title: 'Title Ascending',
        key: 'title',
        reverse: false
    },
    {
        id: 4,
        title: 'Title Descending',
        key: 'title',
        reverse: true
    }
    ];

    vm.order = vm.orders[0];
    vm.new = {};
    vm.addShow = function () {
        vm.shows.push(vm.new);
        vm.new = {};
    };
});