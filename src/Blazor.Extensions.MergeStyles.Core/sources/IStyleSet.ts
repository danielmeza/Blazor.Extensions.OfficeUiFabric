import { IStyle } from './IStyle';
import { IStyleFunctionOrObject, IStyleFunction } from './IStyleFunction';

export type Diff<T extends keyof any, U extends keyof any> = ({ [P in T]: P } &
  { [P in U]: never } & { [x: string]: never })[T];

export type Omit<U, K extends keyof U> = Pick<U, Diff<keyof U, K>>;

/**
 * A style set is a dictionary of display areas to IStyle objects.
 * It may optionally contain style functions for sub components in the special `subComponentStyles`
 * property.
 */
export type IStyleSet<TStyleSet extends IStyleSet<TStyleSet>> = {
  [P in keyof Omit<TStyleSet, 'subComponentStyles'>]: IStyle
} & {
  subComponentStyles?: { [P in keyof TStyleSet['subComponentStyles']]: IStyleFunctionOrObject<any, IStyleSet<any>> };
};

/**
 * A concatenated style set differs from `IStyleSet` in that subComponentStyles will always be a style function.
 */
export type IConcatenatedStyleSet<TStyleSet extends IStyleSet<TStyleSet>> = {
  [P in keyof Omit<TStyleSet, 'subComponentStyles'>]: IStyle
} & {
  subComponentStyles?: { [P in keyof TStyleSet['subComponentStyles']]: IStyleFunction<any, IStyleSet<any>> };
};

/**
 * A processed style set is one which the set of styles associated with each area has been converted
 * into a class name. Additionally, all subComponentStyles are style functions.
 */
export type IProcessedStyleSet<TStyleSet extends IStyleSet<TStyleSet>> = {
  [P in keyof Omit<TStyleSet, 'subComponentStyles'>]: string
} & {
  subComponentStyles?: { [P in keyof TStyleSet['subComponentStyles']]: IStyleFunction<any, IStyleSet<any>> };
};
