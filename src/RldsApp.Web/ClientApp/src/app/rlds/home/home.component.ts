import { Component, OnInit, ViewChild } from '@angular/core';
import { UIChart } from 'primeng/chart';
import { defaultRequestErrorHandler } from '../../../infrastructure/interceptors/error-interceptor';
import { BarChart, DoughnutChart, HomeClient } from '../../../infrastructure/services-api/rlds-api';
import { LayoutService } from '../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  @ViewChild("barChart") barChart: UIChart;

  dataBar: BarChart;
  dataDo: DoughnutChart;
  products: CarouselItem[];
  responsiveOptions;

  constructor(private readonly layoutService: LayoutService,
    private readonly homeClient: HomeClient,
  ) { }

  ngOnInit(): void {
    this.layoutService.setAppTitle("Strona główna");
    this.getChartData();
  }

  test() {
    let a = this.barChart.getBase64Image();
    console.log(a);
  }

  getChartData() {

    this.homeClient.getGroup(new Date().toUTCString(), "1.0").subscribe(r => {

      r.doughnut['datasets'] = [{
        data: r.doughnut.dataSet,
        backgroundColor: [
          "#FF6384",
          "#36A2EB",
        ],
        hoverBackgroundColor: [
          "#FF6384",
          "#36A2EB",
        ]
      }];

      r.bar['datasets'] = [{
        label: 'Przychody',
        backgroundColor: '#42A5F5',
        borderColor: '#1E88E5',
        data: r.bar.dataSets[0].data
      }, {
        label: 'Wydatki',
        backgroundColor: '#9CCC65',
        borderColor: '#7CB342',
        data: r.bar.dataSets[1].data
      }];


      this.dataDo = r.doughnut;
      this.dataBar = r.bar;


    }, error => defaultRequestErrorHandler(this.layoutService, error));

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

  }
}


export class CarouselItem {
  name;
  price;
  inventoryStatus;
  image;
}
