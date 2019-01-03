import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlowerrequestComponent } from './flowerrequest.component';

describe('FlowerrequestComponent', () => {
  let component: FlowerrequestComponent;
  let fixture: ComponentFixture<FlowerrequestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlowerrequestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlowerrequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
