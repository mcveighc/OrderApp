import { HttpClient, HttpHeaders } from "@angular/common/http";
import { encode } from 'base-64'

export abstract class ServiceClientBase {
  constructor(
    private readonly httpClient: HttpClient,
    private readonly baseUrl: string,
    private readonly endpoint: string
  ) {}

  public async get<TResponse>(...params: string[]): Promise<TResponse> {
    const url = this.getEndpointUri(...params);
    const response = await this.httpClient
      .get<TResponse>(url, { headers: this.getHeaders() })
      .toPromise();

    return response;
  }

  public async post<TResponse>(
    body: any,
    ...uriParams: string[]
  ): Promise<TResponse> {
    const url = this.getEndpointUri(...uriParams);
    const requestBody = JSON.stringify(body);

    const response = await this.httpClient
      .post<TResponse>(url, requestBody, { headers: this.getHeaders() })
      .toPromise();

    return response;
  }

  public async put<TResponse>(body: any, ...uriParams: string[]): Promise<TResponse> {
    const url = this.getEndpointUri(...uriParams);
    const requestBody = JSON.stringify(body);

    const response = await this.httpClient
      .put<TResponse>(url, requestBody, { headers: this.getHeaders() })
      .toPromise();

    return response;
  }

  public async delete<TResponse>(...uriParams: string[]): Promise<TResponse> {
    const url = this.getEndpointUri(...uriParams);

    const response = await this.httpClient
      .delete<TResponse>(url, { headers: this.getHeaders() })
      .toPromise();

    return response;
  }

  private getHeaders(): HttpHeaders {
    const token = this.getAuthToken();

    const headerOptions = new HttpHeaders({
      "Authorization": token,
      "Content-Type": "application/json",
    });

    return headerOptions;
  }

  /**
   * Generate auth token for API request
   * */
  private getAuthToken() {
    const insecureAuthHeader = {
      isAdmin: true,
      user: "BGLUser",
    };

    // Really insecure way of creating a bearer token but as an example
    // without auth token server we just create a bearer token via base64
    const authTokenBody = JSON.stringify(insecureAuthHeader);
    const base64Token = encode(authTokenBody);

    const token = `Bearer ${base64Token}`;

    return token;
  }

  /**
   * Generate request URL
   * @param uriParts
   */
  private getEndpointUri(...uriParts: string[]): string {
    return [this.baseUrl, this.endpoint, uriParts].join("/");
  }
}
