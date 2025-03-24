export interface IResult<T> {
    returned: T | undefined;
    message: string | undefined;
}

export type IResultBool = IResult<boolean>;