import { TestBed } from '@angular/core/testing';

import { OrderClientService } from './order-client.service';

describe('OrderClientService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: OrderClientService = TestBed.get(OrderClientService);
    expect(service).toBeTruthy();
  });
});
