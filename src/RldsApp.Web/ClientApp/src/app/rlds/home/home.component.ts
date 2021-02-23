import { Component, OnInit } from '@angular/core';
import { LayoutService } from '../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  dataBar: any;
  dataDo: any;
  products: CarouselItem[];
  responsiveOptions;

  constructor(private readonly layoutService: LayoutService) { }

  ngOnInit(): void {
    this.layoutService.setAppTitle("Strona główna");
    this.getChartData();
  }

  getChartData() {
    this.responsiveOptions = [
      {
        breakpoint: '1024px',
        numVisible: 3,
        numScroll: 3
      },
      {
        breakpoint: '768px',
        numVisible: 2,
        numScroll: 2
      },
      {
        breakpoint: '560px',
        numVisible: 1,
        numScroll: 1
      }
    ];

    this.products = [
      { name: "1", image: "https://primefaces.org/primeng/showcase/assets/showcase/images/demo/product/chakra-bracelet.jpg", inventoryStatus: "New", price: 200 },
      { name: "2", image: "https://primefaces.org/primeng/showcase/assets/showcase/images/demo/product/blue-band.jpg", inventoryStatus: "Old", price: 1200 },
      { name: "3", image: "https://primefaces.org/primeng/showcase/assets/showcase/images/demo/product/bracelet.jpg", inventoryStatus: "Elder Scrolls", price: 25 },
      { name: "4", image: "https://primefaces.org/primeng/showcase/assets/showcase/images/demo/product/brown-purse.jpg", inventoryStatus: "New", price: 25 },
      { name: "5", image: "https://primefaces.org/primeng/showcase/assets/showcase/images/demo/product/gaming-set.jpg", inventoryStatus: "New", price: 250 },
      { name: "6", image: "https://primefaces.org/primeng/showcase/assets/showcase/images/demo/product/black-watch.jpg", inventoryStatus: "Elder Scrolls", price: 125 },
    ]

    this.dataBar = {
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [
        {
          label: 'My First dataset',
          backgroundColor: '#42A5F5',
          borderColor: '#1E88E5',
          data: [65, 59, 80, 81, 56, 55, 40]
        },
        {
          label: 'My Second dataset',
          backgroundColor: '#9CCC65',
          borderColor: '#7CB342',
          data: [28, 48, 40, 19, 86, 27, 90]
        }
      ]
    };

    this.dataDo = {
      labels: ['A', 'B', 'C'],
      datasets: [
        {
          data: [300, 50, 100],
          backgroundColor: [
            "#FF6384",
            "#36A2EB",
            "#FFCE56"
          ],
          hoverBackgroundColor: [
            "#FF6384",
            "#36A2EB",
            "#FFCE56"
          ]
        }]
    };
  }
}


export class CarouselItem {
  name;
  price;
  inventoryStatus;
  image;
}
