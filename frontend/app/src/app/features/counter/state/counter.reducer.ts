import { createReducer, on } from '@ngrx/store';
import { CounterEvents, ValidCountbyOptions } from './counter.actions';

export interface CountState {
  current: number; // what should it start at?
  by: ValidCountbyOptions;
}

const initialState: CountState = {
  current: 0,
  by: 1,
};

export const reducer = createReducer(
  initialState,
  on(CounterEvents.countIncremented, (oldState) => {
    return { ...oldState, current: oldState.current + oldState.by }; // Creates a state that looks similar to the old one + 1
  }),
  on(CounterEvents.countDecremented, (oldState) => {
    return { ...oldState, current: oldState.current - oldState.by }; // Creates a state that looks similar to the old one + 1
  }),
  on(CounterEvents.countReset, (s) => {
    return { ...s, current: 0 };
  }),
  on(CounterEvents.countBySet, (s, a) => ({ ...s, by: a.by })),
  on(CounterEvents.counterData, (s, a) => a.payload)
);
