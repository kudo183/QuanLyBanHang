import { Injectable } from '@angular/core';
import { ChiPhiPartial } from './partial/chi-phi-partial';

@Injectable()
export class PartialMethodService {

    initFilterPartial(className, parameters) {

    }

    loadReferenceDataPartial(className, parameters) {

    }
    processDataModelBeforeAddToEntitiesPartial(className, parameters) {

    }

    processNewAddedDataModelPartial(className, parameters) {

    }

    afterLoadPartial(className, parameters) {
        switch (className) {
            case ChiPhiPartial.className:
                ChiPhiPartial.afterLoad(parameters);
        }
    }
}