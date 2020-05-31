let sumCategoryAmounts = [];

fetch("https://localhost:44385/api/SumCategoryAmount")
    .then(res => res.json())
    .then(result => {
        sumCategoryAmounts = result;
        var category = sumCategoryAmounts.map(item => GetCategory(item.category));
        var totalAmount = sumCategoryAmounts.map(item => Math.round(item.totalAmount));

        var ctx = document.getElementById('myChart').getContext('2d');

        var chart = new Chart(ctx, {
            data: {
                datasets: [{
                    data: totalAmount,
                    backgroundColor: ['Red', 'Yellow', 'Blue', 'Orange', 'Green', 'Black'],
                    hoverBackgroundColor: ['Red', 'Yellow', 'Blue', 'Orange', 'Green', 'Black']
                }],

                // These labels appear in the legend and in the tooltips when hovering different arcs
                labels: category
            },
            type: 'pie',
            options: {
                borderAlign: 'centre'
            }
        });
    });

//sumCategoryAmounts = [
//    { "totalAmount": 4.56, "category": 0 }, { "totalAmount": 17.89, "category": 1 }, { "totalAmount": 8.32, "category": 2 },
//    { "totalAmount": 2.87, "category": 3 }, { "totalAmount": 6.99, "category": 4 },
//    { "totalAmount": 2.99, "category": 5 }
//];

//var category = sumCategoryAmounts.map(item => GetCategory(item.category));
//var totalAmount = sumCategoryAmounts.map(item => Math.round(item.totalAmount));

//var ctx = document.getElementById('myChart').getContext('2d');

//var chart = new Chart(ctx, {
//    data: {
//        datasets: [{
//            data: totalAmount,
//            backgroundColor: ['Red', 'Yellow', 'Blue', 'Orange', 'Green', 'Black'],
//            hoverBackgroundColor: ['Red', 'Yellow', 'Blue', 'Orange', 'Green', 'Black']
//        }],

//        // These labels appear in the legend and in the tooltips when hovering different arcs
//        labels: category
//    },
//    type: 'pie',
//    options: {
//        borderAlign: 'centre'
//    }
//});

function GetCategory(category) {
    switch(category) {
        case 0:
            return "Gaming";
        case 1:
            return "Snacks";
        case 2:
            return "Technology";
        case 3:
            return "Subscriptions";
        case 4:
            return "Rent";
        case 5:
            return "Travel";
        default:
            throw `Category:${category} is not implemented.`;
    }
}
