export interface IApiResponse<T = any> {
    status: number;
    data: T;
    message?: string;
}