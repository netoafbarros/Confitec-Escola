export interface Resposta<T>{
  result: T;
  message: string;
  hasError: boolean;
}
