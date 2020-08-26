import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class DynamicService {
  apiName = 'Dynamic';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/Dynamic/sample' },
      { apiName: this.apiName }
    );
  }
}
