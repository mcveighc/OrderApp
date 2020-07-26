import { Injectable } from '@angular/core';
import { ToastrService, IndividualConfig } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor(private readonly toastr: ToastrService) { }

  public showSuccess(message:string, opts?: Partial<IndividualConfig>) {
    const config = Object.assign(this.getDefaultToastConfig(), opts);
    this.toastr.success(message, '', config);
  }

  public showError(message: string, opts?: Partial<IndividualConfig>) {
    const config = Object.assign(this.getDefaultToastConfig(), opts);
    this.toastr.error(message, '', config);
  }

  private getDefaultToastConfig(): Partial<IndividualConfig> {
    return {
      positionClass: 'toast-bottom-center',
      timeOut: 2000,
      closeButton: true
    }
  }
}
