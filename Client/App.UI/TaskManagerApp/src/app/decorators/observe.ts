import { Subject } from 'rxjs';


export function Observe() {
	return function (target: any, propertyKey: string, descriptor: PropertyDescriptor) {
		let originalInit = target.ngOnInit;
		let originalDestroy = target.ngOnDestroy;

		target.ngOnInit = function () {
			if (!this.destroyedSubj) {
				this.destroyedSubj = new Subject<void>();
				this.destroyedObs = this.destroyedSubj.asObservable();
			}

			if (originalInit && typeof originalInit === 'function') {
				originalInit.apply(this, arguments);
			}

			this[propertyKey](this.destroyedObs);
		}


		target.ngOnDestroy = function () {

			originalDestroy && typeof originalDestroy === 'function' && originalDestroy.apply(this, arguments);

			if (this.destroyedSubj) {
				this.destroyedSubj.next();
				this.destroyedSubj.complete();

				this.destroyedSubj = null;
				this.destroyedObs = null;
			}
		}
	}
}
