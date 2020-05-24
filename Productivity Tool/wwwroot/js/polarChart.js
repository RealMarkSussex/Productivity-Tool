var ctx = document.getElementById('myChart').getContext('2d');
var chart = new Chart(ctx, {
    data: {
        datasets: [{
            data: [10, 20, 30],
            backgroundColor: ['Red', 'Yellow', 'Blue'],
            hoverBackgroundColor: ['Red', 'Yellow', 'Blue']
        }],

        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            'Red',
            'Yellow',
            'Blue'
        ]
    },
    type: 'polarArea',
    options: {
        borderAlign: 'centre'
    }
});