import { Component, OnInit } from '@angular/core';
import { DynamicService } from '../services/dynamic.service';

@Component({
  selector: 'lib-dynamic',
  template: ` <p>dynamic works!</p> `,
  styles: [],
})
export class DynamicComponent implements OnInit {
  constructor(private service: DynamicService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
